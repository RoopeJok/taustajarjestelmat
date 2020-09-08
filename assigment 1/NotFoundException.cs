public class NotFoundException : System.Exception
{
    public NotFoundException() : base() { }
    public NotFoundException(string errormesssage) : base(errormesssage) { }
    public NotFoundException(string errormesssage, System.Exception exception) : base(errormesssage, exception) { }
    protected NotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}