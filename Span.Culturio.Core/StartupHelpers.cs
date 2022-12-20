using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Span.Culturio.Core.Models.CultureObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Span.Culturio.Core {
    public static class StartupHelpers {
        public static void RegisterApiServices(this IServiceCollection services, string jwtToket) {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c => {
                foreach (string file in Directory.EnumerateFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly))
                    c.IncludeXmlComments(file);

                c.UseAllOfForInheritance();
                c.DocInclusionPredicate((_, _) => true);

            });

            services.AddValidatorsFromAssemblyContaining<CreateCultureObjectValidator>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
