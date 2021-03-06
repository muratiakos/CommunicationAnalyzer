# Analysis of corporate communication
`Analysis of corporate communication` is my thesis work
which - in addition to strategic and analytical overviews
about Business Intelligence solutions - designs and
implements a dedicated BI
system for analyzing communication channels.

The system can be integrated with various channels -
eg: e-mail, UCC and traditional telephony systems -
via standardized connectors and allows analysts to inspect,
correlate and visualize conversations `topics`, `threads` and
relations among `groups` and `users` in various forms and details.

## Implementation
The system uses `Oracle DB` and `Oracle BI` with a custom
designed star-scheme for `OLAP` to support the `.NET WCF`
backend services to provide context analysis.
An example communication channel integration was implemented
via a `JavaMail` collector to process andfeed e-mail messages.
I also developed a full `.NET` desktop app with powerful
graph visualizations and context-relation analysis capabilities.

The document and source-code of my thesis was published in 2010
at BME Department of Telecommunications and Media Informatics.

## Contents
 - [`Binaries`](./Binaries) - Built and submitted thesis binaries
 - [`Docs`](./Docs) - Thesis document and resources
 - [`References`](./References) - Original 3rd party libraries referenced
 - [`Screenshots`](./Screenshots) - Basic screens of the running system
 - [`Scripts`](./Scripts) - OLTP, OLAP schemas and data-seeder scripts
 - [`Sources`](./Sources) - .NET C# and and Java EE projects

## Remarks
Special thanks to my university consultant, Zsolt Kardkovács.