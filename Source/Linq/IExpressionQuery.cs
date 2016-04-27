﻿using System;
using System.Linq.Expressions;

namespace LinqToDB.Linq
{
	public interface IExpressionQuery
	{
		Expression       Expression      { get; }
		string           SqlText         { get; }
		IDataContextInfo DataContextInfo { get; }
	}
}
