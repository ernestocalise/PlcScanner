using System;
using System.Collections.Generic;
using System.Threading;
using Opc.Ua.Server;
using System.Diagnostics;
namespace PlcScanner.Routine
{
    public class RoutineScheduler : IDisposable
    {
        private readonly Timer _timer;
        private readonly object _lock = new object();
        private readonly List<BaseRoutine> _routines = new List<BaseRoutine>();
        private readonly ServerSystemContext _context;
        private readonly Stopwatch _sw = Stopwatch.StartNew();
        public RoutineScheduler(ServerSystemContext context)
        {
            _context = context;
            _timer = new Timer(OnTick, null, 0, 100);
        }
        public void RegisterRoutine(BaseRoutine routine)
        {
            lock (_lock)
            {
                _routines.Add(routine);
            }
        }
        private void OnTick(object state)
        {
            lock (_lock)
            {
                var now = _sw.Elapsed;
                foreach(var routine in _routines)
                {
                    routine.Execute(now, _context);
                }
            }
        }

        public BaseRoutine GetRoutineByName(string name)
        {
            lock (_lock)
            {
                foreach (var routine in _routines)
                {
                    if (routine.Name == name)
                        return routine;
                }
            }
            return null;
        }
        public void StopAllRoutines()
        {
            lock (_lock)
            {
                foreach (var routine in _routines)
                    routine.Stop();
            }
        }

        public void StartRoutine(string name)
        {
            lock (_lock)
            {
                foreach (var routine in _routines)
                {
                    if (routine.Name == name)
                        routine.Start(_sw.Elapsed);
                }
            }
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
