using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace Utils.Time
{
    /// <summary>
    /// A class for a countdown timer with a 1 second tick rate
    /// </summary>
    public class Timer : INotifyPropertyChanged
    {
        private TimeSpan _countdown = TimeSpan.Zero;

        /// <summary>
        /// Gets or Sets the remaining time
        /// </summary>
        public TimeSpan Countdown
        {
            get
            {
                return _countdown;
            }

            set
            {
                if (value != _countdown)
                {
                    _countdown = value;
                    OnPropertyChanged("Countdown");
                }
            }
        }

        private TimeSpan duration;
        private DispatcherTimer timer;

        /// <summary>
        /// Initialises a new instance of the class <see cref="Timer"/>
        /// </summary>
        /// <param name="duration">The initial duration</param>
        public Timer(TimeSpan duration)
        {
            this.duration = duration;
            Countdown = duration;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(this.TimerTick);
        }

        /// <summary>
        /// Starts the timer
        /// </summary>
        public void Start()
        {
            timer.Start();
        }

        /// <summary>
        /// Stops the timer
        /// </summary>
        public void Stop()
        {
            timer.Stop();
        }

        /// <summary>
        /// Restarts the timer with it's initial duration
        /// </summary>
        public void Restart()
        {
            Countdown = duration;
            if (!timer.IsEnabled)
                timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            Countdown = Countdown.Subtract(TimeSpan.FromSeconds(1));

            if (Countdown == TimeSpan.Zero)
            {
                timer.Stop();
                NotifyCountdownEnd();
            }
        }

        /// <summary>
        /// Event fired when the <see cref="Countdown"/> property hits 0
        /// </summary>
        public event EventHandler CountdownEnd;

        private void NotifyCountdownEnd()
        {
            var handler = CountdownEnd;
            if (null != handler)
            {
                handler(this, new EventArgs());
            }
        }

        /// <summary>
        /// Event fired if a property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
