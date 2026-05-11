Public Class frmOrderTables

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public SelectedTable As OrderTable

    Private Sub frmOrderTables_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Using Conn As New System.Data.SqlClient.SqlConnection(Fmain.LOCAL_CONN_STR)
            Using Comm As New SqlClient.SqlCommand
                Dim tablegroups As New List(Of OrderTableGroup)
                Comm.Connection = Conn
                Comm.CommandText = "select distinct g.id, g.code, g.name, g.sort_id, g.active from order_tablegroups g inner join order_tables o on g.id = o.group_id where g.active = 1 and o.active = 1"
                Conn.Open()
                Using greader As SqlClient.SqlDataReader = Comm.ExecuteReader()
                    While greader.Read()
                        Dim group As New OrderTableGroup With {.Id = greader.GetInt32(greader.GetOrdinal("id")),
                                                                  .Code = greader.Item("code").ToString(),
                                                                  .Name = greader.Item("name").ToString(),
                                                                  .Active = greader.GetBoolean(greader.GetOrdinal("active"))
                                                                 }
                        If Not IsDBNull(greader.Item("sort_id")) Then
                            group.SortId = greader.GetInt32(greader.GetOrdinal("sort_id"))
                        End If
                        tablegroups.Add(group)
                    End While
                End Using

                Comm.CommandText = "select t.id, t.code, t.name, t.description, t.sort_id, t.active, cast(isnull(o.order_closed, 1) as bit) is_empty, o.check_n, o.supervisor, o.guests from order_tables t left join table_orders o on t.id = o.table_id and o.order_closed = 0 where t.active = 1 and t.group_id = @group_id"
                Comm.Parameters.Add("@group_id", SqlDbType.Int)
                Dim reader As SqlClient.SqlDataReader = Nothing
                Dim lblFont = New Font(flpTableButtons.Font.Name, 9, FontStyle.Bold)
                For Each grp In tablegroups
                    Dim tlpButtons As TableLayoutPanel = tlpGrid

                    For Each tlptbl As Control In tlpGrid.Controls
                        If tlptbl.Name.Replace("tlp", "") = grp.Code Then
                            tlpButtons = tlptbl
                            Exit For
                        End If
                    Next

                    Dim label As New Label With {.Name = grp.Code,
                                                 .Text = grp.Name,
                                                 .ForeColor = Color.GhostWhite,
                                                 .Margin = New Padding(4, 4, 4, 0),
                                                 .AutoSize = False,
                                                 .Width = 84,
                                                 .Height = 88
                                                }
                    label.Font = lblFont
                    flpTableButtons.Controls.Add(label)

                    Comm.Parameters("@group_id").Value = grp.Id
                    reader = Comm.ExecuteReader()
                    While reader.Read()

                        Dim orderTable As New OrderTable With {.Id = reader.GetInt32(reader.GetOrdinal("id")),
                                                        .Code = reader.Item("code").ToString(),
                                                        .Name = reader.Item("name").ToString(),
                                                        .Description = reader.Item("description").ToString(),
                                                        .Active = reader.GetBoolean(reader.GetOrdinal("active"))
                                                       }

                        If Not IsDBNull(reader.Item("is_empty")) Then
                            orderTable.IsEmpty = reader.GetBoolean(reader.GetOrdinal("is_empty"))
                        End If
                        If Not IsDBNull(reader.Item("sort_id")) Then
                            orderTable.SortId = reader.GetInt32(reader.GetOrdinal("sort_id"))
                        End If
                        If Not IsDBNull(reader.Item("check_n")) Then
                            orderTable.CheckN = reader.GetInt32(reader.GetOrdinal("check_n"))
                        End If
                        If Not IsDBNull(reader.Item("supervisor")) Then
                            orderTable.Supervisor = reader.Item("supervisor").ToString()
                        End If
                        If Not IsDBNull(reader.Item("guests")) Then
                            orderTable.Guests = reader.GetInt32(reader.GetOrdinal("guests"))
                        End If

                        Dim button As New Windows.Forms.Button With {.Name = orderTable.Code,
                                                                     .Text = orderTable.Name,
                                                                     .Width = 102, .Height = 88,
                                                                     .BackColor = IIf(orderTable.IsEmpty = True, Color.PaleGreen, Color.OrangeRed),
                                                                     .ForeColor = IIf(orderTable.IsEmpty = True, Color.Black, Color.White),
                                                                     .Tag = orderTable,
                                                                     .Margin = New Padding(4)
                                                                    }
                        AddHandler button.Click, AddressOf TableButton_Click
                        flpTableButtons.Controls.Add(button)

                        For Each btn As Control In tlpButtons.Controls
                            If btn.GetType() Is Reflection.Assembly.GetAssembly(btn.GetType()).GetType("System.Windows.Forms.Button") Then
                                If btn.Name = orderTable.Code Then
                                    btn.Tag = orderTable
                                    btn.Text = orderTable.Name
                                    btn.BackColor = IIf(orderTable.IsEmpty = True, Color.LightGreen, Color.OrangeRed)
                                    btn.ForeColor = IIf(orderTable.IsEmpty = True, Color.Black, Color.White)
                                    AddHandler btn.Click, AddressOf TableButton_Click
                                End If
                            End If
                        Next
                    End While

                    flpTableButtons.SetFlowBreak(flpTableButtons.Controls(flpTableButtons.Controls.Count - 1), True)
                    reader.Close()
                Next
                If Not reader Is Nothing Then
                    reader.Close()
                End If
            End Using
        End Using

    End Sub

    Private Sub TableButton_Click(sender As System.Object, e As System.EventArgs)
        SelectedTable = CType(CType(sender, Button).Tag, OrderTable)
        DialogResult = DialogResult.OK
    End Sub

    Private Sub btnSwitchViews_Click(sender As System.Object, e As System.EventArgs) Handles btnSwitchViews.Click
        If flpTableButtons.Visible = False And tlpGrid.Visible = True Then
            flpTableButtons.Visible = True
            tlpGrid.Visible = False
        Else
            flpTableButtons.Visible = False
            tlpGrid.Visible = True
        End If
    End Sub
End Class