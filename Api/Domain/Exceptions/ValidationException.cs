﻿namespace Api.Domain.Exceptions;

public class ValidationException(string message) : Exception(message);
