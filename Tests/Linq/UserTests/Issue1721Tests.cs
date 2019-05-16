﻿using LinqToDB;
using LinqToDB.Mapping;
using NUnit.Framework;
using System;

namespace Tests.UserTests
{
	[TestFixture]
	public class Issue1721Tests : TestBase
	{
		public class I1721Model
		{
			[Column(DataType = DataType.DateTime2, Precision = 7), NotNull]
			public DateTime BadField { get; set; }
		}

		[ActiveIssue(1721, Configuration = ProviderName.SqlServer2008)]
		[Test]
		public void Issue1721Test([IncludeDataSources(TestProvName.AllSqlServer2008Plus)] string context)
		{
			using (var db = GetDataContext(context))
			{
				Assert.DoesNotThrow(() =>
				{
					using (var temp = db.CreateTempTable<I1721Model>("Issue1721"))
					{ }
				}, 
				"CreateTempTable with `DateTime2(7)` field.");
			}
		}
	}
}
