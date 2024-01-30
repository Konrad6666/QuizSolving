using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Threading;


namespace WpfApp1_RozwiazywanieQuizu.ViewModel
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        private DispatcherTimer _timer;
        private int _secondsElapsed;

        public event PropertyChangedEventHandler PropertyChanged;

        public TimerViewModel()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += OnTimerTick;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            SecondsElapsed++;
        }

        public int SecondsElapsed
        {
            get { return _secondsElapsed; }
            set
            {
                _secondsElapsed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SecondsElapsed)));
            }
        }

        public void StartTimer()
        {
            _timer.Start();
        }

        public void StopTimer()
        {
            _timer.Stop();
        }
    }
}
