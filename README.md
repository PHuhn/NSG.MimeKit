# NSG.MimeKit
## Overview
This solution contains .Net Standard projects as follows:
- A collection of support functions for MimeKit (NSG.MimeKit.Extensions)

## NSG.MimeKit.Extensions

MailKit/MimeKit libraries are commonly use in a .Net Core application.
NSG.MimeKit.Extensions library uses the MimeKit namespace and fluently extends the MimeMessage and BodyBuilder classes.

Example from unit tests:
```
Task<MimeMessage> _email = (new MimeMessage())
    .From(_fromAddress).To(_toAddress)
    .Subject(_subject).Body(
        Extensions.TextBody(_message)
            .Attachment(_buffer, "Text.txt", "text/plain;charset=utf-8")
    ).SendAsync(); // "localhost", 25, false, "", "");
```

## NSG.MimeKit_Tests

NSG.MimeKit_Tests is a project of MS unit tests for the library.
One can view the tests for examples in using the functions.

Also, I used a fake SMTP server to build and test the library. The fake SMTP server is an NPM install. It is globally installed by the following command:
```
npm install -g fake-smtp-server
```

The following launches the server on port 25:
```
fake-smtp-server --smtp-port 25 --http-port 10080 --max 10
```
The Fake SMTP Server documentation is located [here](https://github.com/ReachFive/fake-smtp-server).

You can use your own SMTP solution to the problem of testing.

## Docs

Currently having problems getting Sandcastle Help Builder to work with .Net Standard 2.0.

## Wiki

The Wiki pages were created by cs2media_wiki.py python script.
The mediwiki scripts are located [here](https://github.com/PHuhn/py-media-wiki).
