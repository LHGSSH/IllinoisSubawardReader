# IllinoisSubawardReader

Reads Excel spreadsheets containing subaward and subrecipient info and prints a summary.

For each Excel file in the `Data` subfolder, it prints:
- The file name
- A list of all subrecipient names found in the file

Afterwards, it prints a distinct list of all subrecipients across all files, along with the total subaward amount each subrecipient received.

---

## Assumptions & Design Decisions

The following documents questions I would normally raise with a stakeholder, along with the assumptions I made for this implementation.

### File Format & Folder

- **What file types should be supported?**
  *Only `.xlsx` files are supported. `.xls`, `.csv`, and other formats are out of scope.*

- **What folder should the app read from, and should it be hard-coded?**
  *The app automatically reads from a folder named `Data` located in the same directory as the executable. The folder is not user-configurable.*

- **Should cloud storage (e.g., Google Drive, Dropbox) be supported?**
  *No — only local folders are supported.*

- **What if a new file is added while the app is running?**
  *The app only reads files present in `Data` at startup. To pick up new files, restart the app.*

---

### Spreadsheet Layout

- **What does "this format" mean? The three example files have slightly different layouts.**
  *File 2 places the subrecipient name in column B alongside the "Subaward:" label, while files 1 and 3 place it in column C. File 3 also has more than one Period column.*
  *The app handles both column layouts and assumes the general section structure (Senior Personnel, Other Personnel, etc.) is consistent across files.*

- **Will files always have exactly one worksheet?**
  *Yes, this is assumed.*

---

### Subaward Amounts

- **Should decimals be supported? What format should amounts be printed in?**
  *Yes. Amounts are printed in standard USD currency format (e.g., `$1,234.56`).*

- **What do Sponsor and Cost Share mean under the Total column? Should they be added together?**
  *Only the Sponsor amount is used, as all the subawards only have values under that column.*

- **How are the total amounts identified in the spreadsheet?**
  *Total amounts are assumed to always be colored blue, consistent with the example files.*

- **Do we need to handle the Exempt Subaward Costs?**
  *No, these are out of scope.*

---

### Miscellaneous

- **File 3 appears to have a missing subrecipient name.**
  *Assumed to be a typo. The entry is included in the output with an empty name.*