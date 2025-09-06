using BusinessLayer.Abstract;
using BusinessLayer.Concrate;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFrameWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class IServicesBLL
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDestinitionServic, DestinitonsManager>();
            services.AddScoped<IDestinationDAL, EfDestinitionDAL>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDAL, EfCommentDAL>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDAL, EfUserDAL>();

            services.AddScoped<IAbout2Service, Aboute2Manager>();
            services.AddScoped<IAbout2DAL, EfAbout2DAL>();

            services.AddScoped<IFeatureServic, FeatureManager>();
            services.AddScoped<IFeatureDAL, EfFeatureDAL>();

            services.AddScoped<ITestimonialServic, TestimonialManeger>();
            services.AddScoped<ITestimonialDAL, EfTestimonialDAL>();

            services.AddScoped<IReservationService,ReservationManager>();
            services.AddScoped<IReservationDal,EfReservationDAL>();

        }
    }
}
