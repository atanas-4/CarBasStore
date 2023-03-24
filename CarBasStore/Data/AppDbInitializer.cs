using CarBasStore.Models;
using CarBasStore.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBasStore.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();



                

                if (!context.Brands.Any())
                {
                    context.Brands.AddRange(new List<Brand>()
                    {
                        new Brand()
                        {
                            FullName = "Brands 1",
                            Bio = "This is the Bio of the first Brands",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Brand()
                        {
                            FullName = "Brands 2",
                            Bio = "This is the Bio of the second Brands",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Brand()
                        {
                            FullName = "Brands 3",
                            Bio = "This is the Bio of the second Brands",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Brand()
                        {
                            FullName = "Brands 4",
                            Bio = "This is the Bio of the second Brands",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Brand()
                        {
                            FullName = "Brands 5",
                            Bio = "This is the Bio of the second Brands",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                
                if (!context.CarProducts.Any())
                {
                    context.CarProducts.AddRange(new List<CarProduct>()
                    {
                        new CarProduct()
                        {
                            Name = "Life",
                            Description = "This is the Life CarProducts description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                             CarProductCategory = CarProductCategory.Documentary
                        },
                        new CarProduct()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the CarProducts Redemption description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                             CarProductCategory = CarProductCategory.Documentary

                        },
                        new CarProduct()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                             CarProductCategory = CarProductCategory.Documentary
                        },
                        new CarProduct()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                             CarProductCategory = CarProductCategory.Documentary
                        },
                        new CarProduct()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                             CarProductCategory = CarProductCategory.Documentary
                        },
                        new CarProduct()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                             CarProductCategory = CarProductCategory.Documentary
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Brand_CarProducts.Any())
                {
                    context.Brand_CarProducts.AddRange(new List<Brand_CarProduct>()
                    {
                        new Brand_CarProduct()
                        {
                            BrandId = 1,
                            CarProductId = 1
                        },
                        new Brand_CarProduct()
                        {
                            BrandId = 3,
                            CarProductId = 1
                        },

                         new Brand_CarProduct()
                        {
                            BrandId = 1,
                            CarProductId = 2
                        },
                         new Brand_CarProduct()
                        {
                            BrandId = 4,
                            CarProductId = 2
                        },

                        new Brand_CarProduct()
                        {
                            BrandId = 1,
                            CarProductId = 3
                        },
                        new Brand_CarProduct()
                        {
                            BrandId = 2,
                            CarProductId = 3
                        },
                        new Brand_CarProduct()
                        {
                            BrandId = 5,
                            CarProductId = 3
                        },


                        new Brand_CarProduct()
                        {
                            BrandId = 2,
                            CarProductId = 4
                        },
                        new Brand_CarProduct()
                        {
                            BrandId = 3,
                            CarProductId = 4
                        },
                        new Brand_CarProduct()
                        {
                            BrandId = 4,
                            CarProductId = 4
                        },


                        new Brand_CarProduct()
                        {
                            BrandId = 2,
                            CarProductId = 5
                        },
                        new Brand_CarProduct()
                        {
                            BrandId = 3,
                            CarProductId = 5
                        },
                        new Brand_CarProduct()
                        {
                            BrandId = 4,
                            CarProductId = 5
                        },
                        new Brand_CarProduct()
                        {
                            BrandId = 5,
                            CarProductId = 5
                        },


                        new Brand_CarProduct()
                        {
                            BrandId = 3,
                            CarProductId = 6
                        },
                        new Brand_CarProduct()
                        {
                            BrandId = 4,
                            CarProductId = 6
                        },
                        new Brand_CarProduct()
                        {
                            BrandId = 5,
                            CarProductId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
       }
    }
}
