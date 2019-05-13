# NSG.MimeKit
## Overview
This solution contains .Net Standard projects as follows:
- A collection of support functions for MimeKit (NSG.MimeKit.Extensions)

## The libraries
### NSG.MimeKit.Extensions

Example from unit tests:
```
  Task<MimeMessage> _email = (new MimeMessage())
      .From(_fromAddress).To(_toAddress)
      .Subject(_subject).Body(
          Extensions.TextBody(_message)
              .Attachment(_buffer, "Text.txt", "text/plain")
      ).SendAsync(); // "localhost", 25, false, "", "");
```

### NSG.MimeKit_Tests

### Docs

### Wiki
