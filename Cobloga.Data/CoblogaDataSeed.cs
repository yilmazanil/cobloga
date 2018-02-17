using Cobloga.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobloga.Data
{
    public class CoblogaDataSeed : DropCreateDatabaseIfModelChanges<CoblogaDataContext>
    {
        protected override void Seed(CoblogaDataContext context)
        {
            var posts = new List<BlogPost> {
                new BlogPost { IsPublic = true, CreatedDate = DateTime.Now, Content =  "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam ac lorem vel est egestas porta. Suspendisse auctor sollicitudin dictum. Cras eu urna turpis. Sed mauris lacus, blandit eget nisi at, consequat egestas orci. Donec tincidunt libero odio, eu congue dolor porta in. Sed ut quam accumsan, ultrices felis sit amet, egestas nibh. Praesent vehicula, nisi in hendrerit luctus, ex ante feugiat ante, vel cursus eros dolor nec ligula. Duis dictum mauris facilisis justo ultricies, non sollicitudin felis sagittis. Duis nec est diam. Curabitur et dapibus elit, ut convallis elit. Etiam imperdiet imperdiet augue, ut facilisis lorem finibus at. Suspendisse dignissim quam lorem, eleifend sollicitudin quam varius imperdiet. Etiam augue mi, venenatis et diam id, commodo mattis ex."},
                new BlogPost { IsPublic = true, CreatedDate = DateTime.Now, Content =  "Test" },
                new BlogPost { IsPublic = true, CreatedDate = DateTime.Now, Content =  @"<p>asdasdafd</p><pre id=""__new"" class=""language-css""><code> class=""navbar-header""&gt;&lt;button type = ""button"" class=""navbar-toggle collapsed"" data-toggle=""collapse"" data-target=""#bs-example-navbar-collapse-1"" aria-expanded=""false""&gt;
&lt;span class=""sr-only""&gt;Toggle navigation&lt;/span&gt;&lt;span class=""icon-bar""&gt;&lt;/span&gt; &lt;span class=""icon-bar""&gt;&lt;/span&gt;&lt;span class=""icon-bar""&gt;&lt;/span&gt;&lt;/button&gt; &lt;a class=""navbar-brand"" href=""#""&gt;Brand&lt;/a&gt; &lt;/div&gt;</code></pre>\"}
            };

            posts.ForEach(s => context.CbaPost.Add(s));
            context.SaveChanges();

        }
    }
}
