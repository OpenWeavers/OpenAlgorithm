package org.openalgorithm;

public class InvalidOperationException extends Exception    {
    public InvalidOperationException()  {
        super();
    }
    public InvalidOperationException(String message)    {
        super(message);
    }
    public InvalidOperationException(String message, Throwable cause)   {
        super(message,cause);
    }
}
