<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>进销存管理系统</title>
    <link rel="stylesheet" type="text/css" href="/Scripts/jquery-easyui-1.6.10/themes/default/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="/Scripts/jquery-easyui-1.6.10/themes/icon.css"/>
    <script type="text/javascript" src="/Scripts/jquery-easyui-1.6.10/jquery.min.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-easyui-1.6.10/jquery.easyui.min.js" ></script>
    <script type="text/javascript" src="/Scripts/jquery-easyui-1.6.10/easyloader.js" ></script>
    <script>
        $(function () {
            var oBtnAdd = $("#btnadd");
            oBtnAdd.click(function () {
                $("#dd").dialog("open");
            });
            $("#dlgbtnAdd").click(function () {
                $.ajax({
                    url: "/Handlers/addGoods",
                    type: "get",
                    data: {
                        zl: $("#zl").val(),
                        name: $("#name").val(),
                        des: $("#des").val(),
                        count: $("#kc").val()
                    },
                    success: function (data) {
                        if (data == "1") {
                            //   alert("添加成功");
                            $("#dd").dialog("close");
                            $("#datagrid").datagrid("reload");
                        }
                    }

                });

            });
            //   alert(oBtnAdd);
            $("#btnupdate").click(function () {
                var row = $("#datagrid").datagrid("getSelected");
                // alert(row);
                if (row == null) {
                    alert("您还没有选中行！"); return;
                }
                var id = row.id;
                var name = row.name;
                var desc = row.desc;
                var zl = row.zl;
                var count = row.count;
                $("#upLabId").text(id);
                $("#UpInName").val(name);
                $("#upInZl").val(zl);
                $("#upInCount").val(count);
                $("#upInDesc").val(desc);
                $("#dlgUpdate").dialog("open");
            });
            //--
            $("#upbtnSave").click(function () {
                var Id = $("#upLabId").text();
                var Name = $("#UpInName").val();
                var Zl = $("#upInZl").val();
                var Count = $("#upInCount").val();
                var Desc = $("#upInDesc").val();
                if (Id == "" || Name == "" || Zl == "" || Count == "" || Desc == "") {
                    alert("不能为空！");
                    return;
                }
                $.ajax({
                    url: "Handlers/update",
                    type: "post",
                    data: {
                        "id": Id,
                        "name": Name,
                        "zl": Zl,
                        "count": Count,
                        "Description": Desc
                    },
                    success: function (data) {
                        if (data == "1") {
                            $("#dlgUpdate").dialog("close");
                            $("#datagrid").datagrid("reload");

                        }
                    }
                }); //ajax
            }); //click
            $("#btnSearch").click(function () {
                var key = $("#inSearchKey").val();
                if (key == "") {
                    $('#datagrid').datagrid({ url: 'Handlers/getAllGoods' });
                } else {
                    var url = $("#datagrid").attr("url");
                    //  $("#datagrid").attr("url", "Handlers/Search?key=" + key);
                    //$("#datagrid").datagrid("reload");
                    $('#datagrid').datagrid({ url: 'Handlers/Search', queryParams: { "key": key} });
                    //$('#datagrid').datagrid('options').url = "Handlers/Search?key=" + key;
                }


            }); //click
            $("#btndel").click(function () {
                var row = $("#datagrid").datagrid("getSelected");
                if (row == null) { alert("还没有选择行"); return; }
                $.ajax({
                    url: "/Handlers/delete",
                    data: { "id": row.id },
                    type: "get",
                    success: function (data) {
                        if (data == "1")
                            $("#datagrid").datagrid("reload");
                    }
                });
            }); //click delete
            //----
        });
    </script>
</head>
<body class="easyui-layout">   
    <div data-options="region:'north',title:'进销存系统',split:true" style="height:100px;"></div>   
 <%--   <div data-options="region:'south',title:'South Title',split:true" style="height:100px;"></div> --%>  
   <%-- <div data-options="region:'east',iconCls:'icon-reload',title:'East',split:true" style="width:100px;"></div>  --%> 
    <div data-options="region:'west',title:'菜单',split:true" style="width:100px;"></div>   
    <div data-options="region:'center',title:'操作'" style="padding:5px;background:#eee;">
    <!--center begin-->
     <div>
            <!--dialog-->
              <div id="dd" class="easyui-dialog" title="添加商品" data-options="closed:true" >
                <table>
                    <tr>
                        <td>商品名称</td>
                        <td><input type="text" id="name" /></td>
                    </tr>
                      <tr>
                        <td>描述</td>
                        <td><input type="text" id="des" /></td>
                    </tr>
                      <tr>
                        <td>质量</td>
                        <td><input type="text" id="zl" /></td>
                    </tr>
                    <tr>
                        <td>库存</td>
                        <td><input type="text" id="kc" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <button id="dlgbtnAdd" >确认添加</button>
                        </td>

                    </tr>
                </table>
              </div>  
            <div>
            <!--dialog-->
            <div id="dlgUpdate" class="easyui-dialog" data-options="closed:true" title="修改商品信息">
                 <table>
                    <tr>
                        <td colspan="2">
                        <label>商品ID：</label>
                            <label id="upLabId">ID</label>
                        </td>
                    </tr>
                    <tr>
                        <td>商品名称</td>
                        <td>
                            <input type="text" id="UpInName"/>
                        </td>
                    </tr>
                     <tr>
                        <td>商品质量</td>
                        <td>
                            <input type="text" id="upInZl"/>
                        </td>
                    </tr>
                     <tr>
                        <td>商品库存</td>
                        <td>
                            <input type="text" id="upInCount"/>
                        </td>
                    </tr>
                     <tr>
                        <td>商品描述</td>
                        <td>
                            <input type="text" id="upInDesc"/>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <button id="upbtnSave">保存修改</button>
                        </td>
                    </tr>
                 </table>
            </div>
            <!--dialog-->
            <!--dialog-->
            <!--dialog-->
            <!--dialog-->
                <button id="btnadd" class="easyui-linkbutton" data-options="iconCls:'icon-add'">添加</button>&nbsp;
                <button id="btnupdate" class="easyui-linkbutton" data-options="iconCls:'icon-edit'">修改</button>
                <button id="btndel" class="easyui-linkbutton" data-options="iconCls:'icon-remove'">删除</button>
                <input type="text" placeholder="模糊查询" id="inSearchKey" class="easyui-textbox"/> 
                <button id="btnSearch" class="easyui-linkbutton" data-options="iconCls:'icon-search'">查询</button>
            </div>
              <table id="datagrid" class="easyui-datagrid"     url="/Handlers/getAllGoods"     fit="true" SingleSelect="true" fitColumns="true" pagination="true">
                <thead>
                    <tr>
                        <th data-options="field:'id'"  >商品ID</th>
                        <th data-options="field:'name'"  >商品名称</th>
                        <th data-options="field:'desc'"  >描述信息</th>
                        <th data-options="field:'zl'">质量</th>
                        <th data-options="field:'count'">库存数量</th>
                    </tr>
                </thead>
                <tbody>
            
                 
                     <%--   <%
                            foreach (var item in ViewData["data"] as IList<Models.Goods>)
                            {
                                Response.Write("<tr>");
                                Response.Write("<td>"+item.name+"</td>");
                                Response.Write("<td>" + item.Description + "</td>");
                                Response.Write("<td>" + item.zl + "</td>");
                                Response.Write("<td>" + item.count + "</td>");
                                Response.Write("</tr>");
                            }
                        %>--%>
            
             
                </tbody>
            </table>
            </div>
    </div>   <!--centerend -->
</body>  


 
</html>
