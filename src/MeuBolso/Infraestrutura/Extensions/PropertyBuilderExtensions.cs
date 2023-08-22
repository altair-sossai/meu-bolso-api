using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuBolso.Infraestrutura.Extensions;

public static class PropertyBuilderExtensions
{
    public static void UseDecimalType(this PropertyBuilder<decimal> property, int precision = 18, int scale = 2)
    {
        property
            .HasColumnType($"decimal({precision}, {scale})");
    }
}