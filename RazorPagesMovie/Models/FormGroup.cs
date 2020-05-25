namespace RazorPagesMovie
{
    public class FormGroup
    {

        public static string Form(string Target)
        {
            string[] name = Target.Split(".");
            string target = Target.Replace(".", "_");
            string content = $"<div class=\"form-group\"><label asp-for={target} class=\"control-label\">{name[1]}</label><input name={Target} asp-for={target} class=\"form-control\" /><span asp-validation-for={Target} class=\"text-danger\"></span></div>";



            /*
            <div class="form-group">
                <label asp-for="Movie.Rating" class="control-label"></label>
                <input asp-for="Movie.Rating" class="form-control" />
                <span asp-validation-for="Movie.Rating" class="text-danger"></span>
            
            */
            return content;
        }
    }
}