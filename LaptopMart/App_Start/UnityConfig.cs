using LaptopMart.ApplicationDb;
using LaptopMart.Contracts;
using LaptopMart.Controllers;
using LaptopMart.Implementations;
using LaptopMart.Models;
using LaptopMart.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Data.Entity;
using System.Web;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace LaptopMart
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            
            
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            // container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<AccountController>(new InjectionConstructor(new ResolvedParameter<ICartService>()));
            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterType<IAuthenticationManager>(
                new InjectionFactory(
                    o => System.Web.HttpContext.Current.GetOwinContext().Authentication
                )
            );

            

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<ISupplierRepository, SupplierRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ICartService,CartService>();
            container.RegisterType<ICartRepository, CartRepository>();
            container.RegisterType<ICartItemRepository, CartItemRepository>();





        }
    }
}