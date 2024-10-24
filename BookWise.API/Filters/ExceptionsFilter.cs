﻿using BookWise.Application.Models.ViewModels;
using BookWise.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BookWise.API.Filters;

public class ExceptionsFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BookWiseException)
            HandleBookWiseException(context);
        else
            ThrowUnknownError(context);
    }

    private void HandleBookWiseException(ExceptionContext context)
    {
        if (context.Exception is ValidationErrorsException)
            HandleValidationErrorsException(context);

        if (context.Exception is NotFoundErrorsException)
            HandleNotFoundErrorsException(context);
    }

    private void HandleValidationErrorsException(ExceptionContext context)
    {
        ValidationErrorsException? validationErrorException = context.Exception as ValidationErrorsException;
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        if (!string.IsNullOrEmpty(validationErrorException?.Message))
        {
            context.Result = new ObjectResult(validationErrorException.Message);
        }
        else
        {
            context.Result = new ObjectResult(new ErrorViewModel(validationErrorException.ErrorMessages));
        }
    }

    private void HandleNotFoundErrorsException(ExceptionContext context)
    {
        NotFoundErrorsException? notFounderrorException = context.Exception as NotFoundErrorsException;
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;

        context.Result = new ObjectResult(new ErrorViewModel(notFounderrorException.ErrorMessage));
    }

    private void ThrowUnknownError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ErrorViewModel(context.Exception.Message));
    }
}
