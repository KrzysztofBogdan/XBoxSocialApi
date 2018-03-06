using System.Collections.Generic;

namespace Gametroleum.Social
{
    public class ExecutionContext
    {
        private Dictionary<string, object> _params = new Dictionary<string, object>();

        public ExecutionContext Add(string name, object value)
        {
            _params.Add(name, value);
            return this;
        }

        public object Get(string name)
        {
            return _params.GetValue(name);
        }

        public T Get<T>(string name, T defaultValue)
        {
            object value;

            if (_params.TryGetValue(name, out value)) return (T) value;

            return defaultValue;
        }

        public ExecutionContext Copy()
        {
            var ctx = new ExecutionContext();
            ctx._params = new Dictionary<string, object>(_params);
            return ctx;
        }
    }
}