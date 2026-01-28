using Opc.Ua;
using Opc.Ua.Server;
using PlcScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PlcScanner.Routine
{
    public abstract class BaseRoutine
    {
        public string Name { get; private set; }
        public bool IsPaused { get; private set; }
        private TimeSpan _startTime;
        private TimeSpan _pauseOffset;
        private TimeSpan _pauseStartedAt;
        public DateTime DateStarted { get; private set; } = DateTime.MinValue;
        public DateTime DateEnded { get; private set; } = DateTime.MinValue;
        protected TimeSpan LocalTime { get; private set; }

        protected void SetName(string n)
        {
            this.Name = n;
        }
        public void Start(TimeSpan globalTime)
        {
            _startTime = globalTime;
            _pauseOffset = TimeSpan.Zero;
            _pauseStartedAt = TimeSpan.Zero;
            DateEnded = DateTime.MinValue;
            DateStarted = DateTime.Now;
            IsPaused = false;
        }

        public void Pause()
        {
            if (!IsPaused)
            {
                _pauseStartedAt = LocalTime;
                IsPaused = true;
            }
        }
        public void Resume()
        {
            if (IsPaused)
            {
                _pauseOffset += LocalTime - _pauseStartedAt;
                IsPaused = false;
            }
        }
        public void Stop()
        {
            IsPaused = false;
            DateEnded = DateTime.Now;
        }
        public void Execute(TimeSpan globalTime, ServerSystemContext context) {
            if (DateStarted == DateTime.MinValue)
                return;
            if (IsPaused || DateEnded > DateTime.MinValue)
                return;

            LocalTime = globalTime - _startTime - _pauseOffset;

            if (LocalTime < TimeSpan.Zero)
                return;

            ExecuteInternal(LocalTime, context);            
        }
        public string GetRoutineStatus()
        {
            if (IsPaused)
                return "Paused";
            if (DateEnded > DateTime.MinValue)
                return "Ended";
            if (DateStarted == DateTime.MinValue)
                return "Ready";
            return "Running";
        }
        protected abstract void ExecuteInternal(TimeSpan localTime, ServerSystemContext context);
    }
}