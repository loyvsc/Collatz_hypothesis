namespace Hypothesis
{
    /// <summary>
    /// The Collatz hypothesis
    /// </summary>
    public class Collatz : IDisposable
    {
        public uint Number { get; set; } = 0;
        public int OperationsCount { get; private set; } = 0;
        public bool IsDisposed = false;

        public Collatz() { }

        /// <param name="number">Number</param>
        /// <exception cref="ArgumentException">Occurs when passing the number argument equal to 0</exception>
        public Collatz(uint number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("Number can not be 0");
            }
            Number = number;
        }

        private void CalculateBase()
        {
            switch (Number % 2)
            {
                case 0:
                    {
                        Number /= 2;
                        break;
                    }
                case 1:
                    {
                        Number = 3 * Number + 1;
                        break;
                    }
            }
        }

        /// <summary>
        /// Start calculations
        /// </summary>
        /// <exception cref="ObjectDisposedException">Occurs when trying to use after finalizing</exception>
        public void Calculate()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException("Collatz");
            }
            while (Number != 1)
            {
                CalculateBase();
                OperationsCount++;
            }
        }

        /// <summary>
        /// Start calculations
        /// </summary>
        /// <param name="number">Number</param>
        /// <exception cref="ObjectDisposedException">Occurs when trying to use after finalizing</exception>
        /// <exception cref="ArgumentException">Occurs when passing an argument equal to zero</exception>
        public void Calculate(uint number)
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException("Collatz");
            }
            if (number == 0)
            {
                throw new ArgumentException("Number can not be 0");
            }
            Number = number;
            while (Number != 1)
            {
                CalculateBase();
                OperationsCount++;
            }
        }

        public override string ToString()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException("Collatz");
            }
            return $"We came to 1 in {OperationsCount} steps";
        }

        /// <summary>
        /// Finalizing the object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
            {
                return;
            }
            if (disposing)
            {
                Number = 0;
                OperationsCount = 0;
            }
            IsDisposed = true;
        }
    }
}