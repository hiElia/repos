using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstAddInWeb.Models
{
    public class SpLists
    {
//        Create a provider hosted add in where you will display all the lists on the addig
//            Create a model called SPList
//ID - guid
//Title
//Url
//Call sharepoint and get all the lists.Populate a list of your model with information
//Create a controller from your model and views and on the index view you should list all your lists
//Challenge :  Implement the delete, create, and update views and controllers where you can: 
//Add a new list : Just make it a generic list
//Update a list : change the title
//Remove a list : delete the list.
        public Guid ListId{ get; set; }
        public string  Title { get; set; }
        public string  Url  { get; set; }

    }
}