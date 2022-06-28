using System;
using System.Threading;
using System.Threading.Tasks;

using Nito.AsyncEx;

using SharpDX;
using SharpDX.DXGI;

#nullable enable
namespace Captura.Windows.DesktopDuplication
{
    public class FrameGrabber : IDisposable
    {
        private readonly OutputDuplication _deskDupl;
        private readonly Task _acquireTask;
        private readonly CancellationTokenSource _cts;
        private readonly AsyncManualResetEvent _pulse;
        private AcquireResult? _acquireResult;
        private bool _disposedValue;

        public FrameGrabber(OutputDuplication deskDupl)
        {
            _deskDupl = deskDupl;

            _pulse = new AsyncManualResetEvent(false);
            _cts = new CancellationTokenSource();
            _acquireTask = Task.Run(async () => await AcquireResultAsync(_cts.Token), _cts.Token);
        }

        private async Task AcquireResultAsync(CancellationToken token = default)
        {
            const int TimeoutInMilliseconds = 50;
            while (!token.IsCancellationRequested)
            {
                try
                {
                    Result result = _deskDupl.TryAcquireNextFrame(TimeoutInMilliseconds,
                        out OutputDuplicateFrameInformation frameInfo,
                        out Resource? desktopResource);

                    if (result == ResultCode.WaitTimeout)
                    {
                        Interlocked.Exchange(ref _acquireResult, null);
                    }
                    else
                    {
                        var acquireResult = new AcquireResult(result, frameInfo, desktopResource);
                        Interlocked.Exchange(ref _acquireResult, acquireResult);
                        _pulse.Reset();
                    }
                }
                catch
                {
                    Interlocked.Exchange(ref _acquireResult, new AcquireResult(Result.Fail));
                }

                await _pulse.WaitAsync(token);
            }
        }

        public AcquireResult? Grab()
        {
            AcquireResult? result = Interlocked.Exchange(ref _acquireResult, null);
            return result;
        }

        public void Release()
        {
            _deskDupl.ReleaseFrame();
            _pulse.Set();
        }

        #region IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                _disposedValue = true;

                _cts.Cancel();
                _acquireTask.Wait();
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
