# IllinoisSubawardReader
Reads Excel spreadsheets containing subaward and subrecipient info and prints info about them.

For each Excel file in the Data subfolder, it prints:
- **The file name**
- **A list of all subrecipient names in the format "Subaward: SubRecipientName"**

Afterwards, it prints **a distinct list of all subrecipients along with the total subaward amount
that subrecipient received across all files.**

## Questions I Would Normally Ask + Assumptions I Made
The assignment says that the app should read all spreadsheets from a folder.
- **What file types are we supporting? Are we only supporting .xlsx files, or should we also support .xls, .csv, or other formats?**
- **What folder should the app read from?**
- **Should the folder be something we decide as developers and hard-code into the app?**
- **Should we allow the user to choose the folder to read from, perhaps via a pop-up prompt?**
- **Should we only support reading from local folders, or should we also support reading folders from cloud storage (e.g., Google Drive, Dropbox)?**
- **What happens if a new file is added to the folder while the app is running? Should the app automatically detect and read the new file, or should it only read files that were present when it started?**

*For this implementation, I will assume that the app should only read .xlsx files from a local folder named "Data" that is located in the same directory as the app. It will choose this folder automatically. The app will read all .xlsx files that are present in the "Data" folder when it starts, and it will not automatically detect new files added while it is running. In order to read new files added to the folder, the user must restart the app.*

The assignment says that "the app should work with any spreadsheet in this format." The assignment also provides three .xlsx files as examples.
- **What does "this format" mean? Does it refer to the file format (.xlsx)? Does it refer to the overall layout of the example spreadsheets (A. Senior Personnel, B. Other Personnel, etc.)?** In files 1 and 3, the subrecipient names appear in their own column (column C), but in file 2, they appear in column B lumped in with "Subrecipient:." Plus, file 3 has more than one Period. So the format varies slightly across the three example files.

*For this implementation, I will assume that "this format" refers to the general layout of the spreadsheet - the different sections (Senior Personnel, etc.), the data they contain (salary, costs, etc.), and where they are placed in the file. I will also assume that the subrecipient names can either appear in column B or column C, and that the app should be able to read them from either column.*