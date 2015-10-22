public static void ParseSave(string filename)
    {
        byte[] Data = new byte[SteamRemoteStorage.GetFileSize(filename)];
        int ret = SteamRemoteStorage.FileRead(filename, Data, Data.Length);

        string m_Message = System.Text.Encoding.UTF8.GetString(Data, 0, ret);

        PSTTool.Log(m_Message);
        using (XmlReader reader = XmlReader.Create(new StringReader(m_Message)))
	    {
	        while (reader.Read())
	        {
		    // Only detect start elements.
		    if (reader.IsStartElement())
		    {
		        // Get element name and switch on it.
		        switch (reader.Name)
		        {
                    case "validity":
                        if (reader.Read())
                        {
                            PSTTool.Log("Validity: " + reader.Value.Trim());
                        }
                        break;
                    case "steamid":
                        if (reader.Read())
                        {
                            PSTTool.Log("SteamID: " + reader.Value.Trim());
                        }
                        break;
                    case "data_type":
                        if (reader.Read())
                        {
                            PSTTool.Log("Data Type: " + reader.Value.Trim());
                        }
                        break;
                    case "data_version":
                        if (reader.Read())
                        {
                            PSTTool.Log("Data Version: " + reader.Value.Trim());
                        }
                        break;
                    case "loginname":
                        if (reader.Read())
                        {
                            PSTTool.Log("Login Name: " + reader.Value.Trim());
                        }
                        break;

		        }
		    }
	        }
	    }
    }
