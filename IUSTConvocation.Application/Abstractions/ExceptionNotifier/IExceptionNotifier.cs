﻿namespace IUSTConvocation.Application.Abstractions.ExceptionNotifier;

public interface IExceptionNotifier
{
    void LogToEmail(Exception ex);
}
