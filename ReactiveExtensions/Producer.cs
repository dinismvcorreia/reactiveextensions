namespace ReactiveExtensions
{
    using System;
    using System.Reactive.Subjects;
    using System.Timers;

    public class Producer : IDisposable
    {
        private readonly Subject<TitleArgs> _subject = new Subject<TitleArgs>();
        private readonly Timer _timer = new Timer(1000);

        public Producer()
        {
            _timer.Elapsed += OnElapsed;
            _timer.Start();
        }

        public IObservable<TitleArgs> TitlePublished => _subject;

        public void Dispose()
        {
            _timer.Elapsed -= OnElapsed;
            _timer.Dispose();            
            _subject.Dispose();
        }

        private void OnElapsed(object s, ElapsedEventArgs e)
        {
            var title = Guid.NewGuid().ToString();
            var titleArgs = new TitleArgs(title);
            _subject.OnNext(titleArgs);
        }
    }
}
