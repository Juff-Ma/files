 private void SaveButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (!confirmNotNull(hostname.Text, "Hostname")) { return; }
            else if (!confirmNotNull(this.port.Text, "Rcon Port")) { return; }
            else if (!confirmNotNull(this.queryPort.Text, "Query Port") && this.queryPort.IsEnabled) { return; }


            else if (!confirmInt(this.port.Text, "Rcon Port")) { return; }
            else if (this.queryPort.IsEnabled && !confirmInt(this.queryPort.Text, "Query Port")) { return;  }
            else
            {
                int port = Convert.ToInt32(this.port.Text);
                int? queryPort = this.queryPort.IsEnabled || confirmInt(this.queryPort.Text, "Query Port") ? Convert.ToInt32(this.queryPort.Text) : null;
                queryPort = this.queryPort.IsEnabled ? Convert.ToInt32(this.queryPort.Text) : (queryPort != null ? Convert.ToInt32(this.queryPort.Text) : 0);
                Session session = new Session() { Host = hostname.Text, Port = port, Query = new Query() { Enabled = this.queryPort.IsEnabled, Text = (int)queryPort } };
                if (!App.settings.Sessions.Session.Contains(session))
                {
                    App.settings.Sessions.Session.Add(session);
                    reloadSessions();
                }
            }
        }

private bool confirmInt(string confirm, string errorName)
        {
            bool returnable = true;


            foreach (char c in confirm != null ? confirm.ToCharArray() : new char[] { })
            {
                switch (c)
                {
                    case '0': returnable = true; break;
                    case '1': returnable = true; break;
                    case '2': returnable = true; break;
                    case '3': returnable = true; break;
                    case '4': returnable = true; break;
                    case '5': returnable = true; break;
                    case '6': returnable = true; break;
                    case '7': returnable = true; break;
                    case '8': returnable = true; break;
                    case '9': returnable = true; break;
                    default: returnable = false; break;
                }
                if (returnable == false) 
                {
                    MessageBoxManager.GetMessageBoxCustomWindow(
               new MessageBoxCustomParamsWithImage
               {
                   ButtonDefinitions = new[] {
                        new ButtonDefinition {Name = "Ok", IsDefault = true}
                   },
                   ContentTitle = "Wrong Input",
                   ContentHeader = "Incorrect input in field \"" + errorName + "\"",
                   ContentMessage = "You typed a character into a port field (ports can only contain numbers)",
                   WindowIcon = new WindowIcon("./Ressources/icon.ico"),
                   WindowStartupLocation = WindowStartupLocation.CenterOwner,
                   Icon = new Avalonia.Media.Imaging.Bitmap("./Ressources/Question.ico")
               }).ShowDialog(this);


                    break;
                }
            }


            return returnable;
        }
        private bool confirmNotNull(string confirm, string errorName)
        {
            if (confirm == null)
                {
                    MessageBoxManager.GetMessageBoxCustomWindow(
               new MessageBoxCustomParamsWithImage
               {
                   ButtonDefinitions = new[] {
                        new ButtonDefinition {Name = "Ok", IsDefault = true}
                   },
                   ContentTitle = "Wrong Input",
                   ContentHeader = "Incorrect input in field \"" + errorName + "\"",
                   ContentMessage = "Inputs need to be full!",
                   WindowIcon = new WindowIcon("./Ressources/icon.ico"),
                   WindowStartupLocation = WindowStartupLocation.CenterOwner,
                   Icon = new Avalonia.Media.Imaging.Bitmap("./Ressources/Question.ico")
               }).ShowDialog(this);


            }


            return confirm == null;
        }
