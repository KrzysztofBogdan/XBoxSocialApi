using Gametroleum.Social;

namespace Gametroleum
{
    public class ActionResult
    {
        public static readonly SocialCallback Noop = result => { };
        public static readonly ActionResult Failed = new ActionResult(false);
        public static readonly ActionResult Success = new ActionResult(true);

        private ActionResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public static ActionResult From(bool value)
        {
            return value ? Success : Failed;
        }

        public bool IsSuccess { get; private set; }
    }

    public class ActionResult<TResult>
    {
        public TResult Data;

        public ActionResult()
        {
            IsSuccess = false;
        }

        public ActionResult(TResult result)
        {
            IsSuccess = true;
            Data = result;
        }

        public ActionResult(TResult result, bool isSuccess)
        {
            IsSuccess = isSuccess;
            Data = result;
        }

        public bool IsSuccess { get; private set; }
    }
}