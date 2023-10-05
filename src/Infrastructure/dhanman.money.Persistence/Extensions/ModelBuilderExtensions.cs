﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dhanman.Money.Persistence.Extensions;

internal static class ModelBuilderExtensions
{
    #region Properties
    private static readonly ValueConverter<DateTime, DateTime> UtcValueConverter =
        new ValueConverter<DateTime, DateTime>(outside => outside, inside => DateTime.SpecifyKind(inside, DateTimeKind.Utc));
    #endregion


    #region Methods
    /// <summary>
    /// Applies the UTC date-time converter to all of the properties that are <see cref="DateTime"/> and end with Utc.
    /// </summary>
    /// <param name="modelBuilder">The model builder.</param>
    internal static void ApplyUtcDateTimeConverter(this ModelBuilder modelBuilder)
    {
        foreach (IMutableEntityType mutableEntityType in modelBuilder.Model.GetEntityTypes())
        {
            IEnumerable<IMutableProperty> dateTimeUtcProperties = mutableEntityType.GetProperties()
                .Where(p => p.ClrType == typeof(DateTime) && p.Name.EndsWith("Utc", StringComparison.Ordinal));

            foreach (IMutableProperty mutableProperty in dateTimeUtcProperties)
            {
                mutableProperty.SetValueConverter(UtcValueConverter);
            }
        }
    }
    #endregion

}