namespace EventsManagement.Web.Core.Constants
{
    public enum Roles
    {
        User,
        Admin,
        Moderator
    }

    public class RoleConstants
    {
    }

    //ეს ისე მეგდოს მერე სიდინგისთვის დამჭირდება
    //public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
    //{
    //	UserManager<User> userManager = service.GetService<UserManager<User>>();
    //	RoleManager<IdentityRole<int>> roleManager = service.GetService<RoleManager<IdentityRole<int>>>();
    //	await roleManager.CreateAsync(new IdentityRole<int>(Roles.Admin.ToString()));
    //	await roleManager.CreateAsync(new IdentityRole<int>(Roles.User.ToString()));
    //	await roleManager.CreateAsync(new IdentityRole<int>(Roles.Moderator.ToString()));

    //	var user = new User
    //	{
    //		UserName = "FirstUser",
    //		FirstName = "Name",
    //		LastName = "Lastname",
    //		Email = "rami26@freeuni.edu.ge",
    //	};

    //	var user2 = new User
    //	{
    //		UserName = "LiziRam",
    //		FirstName = "Name",
    //		LastName = "Lastname",
    //		Email = "firstuser@gmail.com",
    //	};

    //	var userInDb = await userManager.FindByEmailAsync(user.Email);
    //	var userInDb2 = await userManager.FindByNameAsync(user2.UserName);
    //	if (userInDb == null)
    //	{
    //		await userManager.CreateAsync(user, "Admin123$");
    //		await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
    //	}
    //	if (userInDb2 == null)
    //	{
    //		await userManager.CreateAsync(user, "Moderator123$");
    //		await userManager.AddToRoleAsync(user, Roles.Moderator.ToString());
    //	}
    //}
}
