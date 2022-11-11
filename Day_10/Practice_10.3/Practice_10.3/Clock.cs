using System;
namespace Practice_10._3
{
    class Clock
    {
        int _second;
        int _minute;
        int _hour;

        public int Second
        {
            get
            {
                return _second;
            }
            set
            {
                if(value >= 0 && value <= 59)
                {
                    _second = value;
                }
            }
        }

        public int Minute
        {
            get
            {
                return _minute;
            }
            set
            {
                if (value >= 0 && value <= 59)
                {
                    _minute = value;
                }
            }
        }

        public int Hour
        {
            get
            {
                return _hour;
            }
            set
            {
                if (value >= 0 && value <= 23)
                {
                    _hour = value;
                }
            }
        }

        public void GetCurrentTime()
        {
            string hour = _hour.ToString("D2");
            string minute = _minute.ToString("D2");
            string second = _second.ToString("D2");

            Console.WriteLine($"{hour}:{minute}:{second}");
        }

        public void addSecond()
        {
            if(_second == 59)
            {
                addMinute();
                _second = 0;
            }
            else
            {
                _second += 1;
            }
        }

        public void addMinute()
        {
            if (_minute == 59)
            {
                addHour();
                _minute = 0;
            }
            else
            {
                _minute += 1;
            }
        }

        public void addHour()
        {
            if (_hour == 23)
            {
                _hour = 0;
            }
            else
            {
                _hour += 1;
            }
        }

        public void subtractSecond()
        {
            if (_second == 0)
            {
                subtractMinute();
                _second = 59;
            }
            else
            {
                _second -= 1;
            }
        }

        public void subtractMinute()
        {
            if (_minute == 0)
            {
                subtractHour();
                _minute = 59;
            }
            else
            {
                _minute -= 1;
            }
        }

        public void subtractHour()
        {
            if (_hour == 0)
            {
                _hour = 23;
            }
            else
            {
                _hour -= 1;
            }
        }
    }
}

