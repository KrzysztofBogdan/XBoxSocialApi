namespace Gametroleum.Social
{
    public delegate void SocialCallback(ActionResult result);
    public delegate void SocialResultCallback<T>(ActionResult<T> result);
}