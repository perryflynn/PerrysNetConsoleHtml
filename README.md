This extension for [PerrysNetConsole](https://github.com/perryflynn/PerrysNetConsole)
generates from the console application output a fancy HTML file.

```cs
var tpl = new FileInfo("template.html");
using (var writer = new CoExHtmlWriter(tpl, Encoding.UTF8) { Title = "A fancy demo" })
{
    CoEx.WriteTitleLarge("A fancy demo");
    CoEx.WriteLine();
    CoEx.WriteTable(tabledata);

    writer.SaveAs(target);
}
```

## Demo

![Demo image](./docs/demo.jpg)