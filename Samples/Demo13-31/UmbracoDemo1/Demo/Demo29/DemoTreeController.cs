using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;

namespace UmbracoDemo1.Demo.Demo29
{
    [Tree("demoSection", "peopleTree", "Demo people tree")]
    [PluginController("Demo29CustomSection")]
    public class DemoTreeController : TreeController
    {
        protected override Umbraco.Web.Models.Trees.TreeNodeCollection GetTreeNodes(string id, System.Net.Http.Formatting.FormDataCollection queryStrings)
        {
            //check if we’re rendering the root node’s children
            if (id == "-1")
            {
                var ctrl = new PersonApiController();
                var nodes = new TreeNodeCollection();

                foreach (var person in ctrl.GetAll())
                {
                    var node = CreateTreeNode(
                        person.Id.ToString(),
                        "-1",
                        queryStrings,
                        person.ToString(),
                        "icon-user",
                        false);

                    nodes.Add(node);

                }
                return nodes;
            }

            //this tree doesn’t suport rendering more than 1 level
            throw new NotSupportedException();
        }

        protected override Umbraco.Web.Models.Trees.MenuItemCollection GetMenuForNode(string id, System.Net.Http.Formatting.FormDataCollection queryStrings)
        {
            //not worying about menu atm
            var menu = new MenuItemCollection();
            menu.Items.Add(new MenuItem { Alias = "test", Name = "Test", Icon = "icon-truck" });
            return menu;
        }
    }
}