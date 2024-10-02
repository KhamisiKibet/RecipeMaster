namespace RecipeMaster.Cells;

public class RecipeDataTemplateSelector : DataTemplateSelector
{
    public RecipeDataTemplateSelector()
    {

    }
    public DataTemplate Normal { get; set; }
    public DataTemplate Special { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        //var Recipe = (Recipe)item; 

        //return Recipe.Description == "Yes Plz" ? Special : Normal;


        // enable code above for true data template selectors
        return Normal;
    }
}
