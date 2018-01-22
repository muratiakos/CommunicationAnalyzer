# Communication Analyzer System - Screenshots

### Basic Query interface - Topic or Participant selection
The basic query interface allows you to select conversation `topics` and `participants` within a time-interval. This will
filter all the conversations in aggregated or in a detailed view for your analysis.

![analysis-basic_search_form.png](./analysis-basic_search_form.png)

### Topic-Group conversation visualization
The most basic communication view shows the conversation the high-level `topics` among `groups` in a direct on indirect graph with the topic `weight` as its relevance and frequency.

![analysis-subject_relation_analysis_group_indirect.png](./analysis-subject_relation_analysis_group_indirect.png)

![analysis-participant_relation_result_group_direct.png](./analysis-participant_relation_result_group_direct.png)

### Detailed User-based communication visualization
You can also drill into details within a `group` or in a `topic` to see more details on the actual conversations in any direction:

![analysis-participant_relation_result_user_directed.png](./analysis-participant_relation_result_user_directed.png)

![analysis-participant_relation_result_user_indirect.png](./analysis-participant_relation_result_user_indirect.png)

Including a `timeline` based thread view for full message history:
![analysis-flow_relation_analysis.png](./analysis-flow_relation_analysis.png)


### Other configuration screens
The following screens demonstrate the basic maintenance and configuration views for the Communication analyzer client and
server.
![main-connection.png](./main-connection.png)

#### Participant search view
The current implementation of this service doesn't integrate with
standard directory services (eg: AD or Google Apps Groups) yet.
![main-participant_selection.png](./main-participant_selection.png)

Multiple addresses can be assigned to same entities for better recognition and analysis both from the UI with mass-replace tools
or via other service connectors and integrators.
![participant_mgmt-replace_tool.png](./participant_mgmt-replace_tool.png)
![participant_mgmt-multiple_addresses.png](./participant_mgmt-multiple_addresses.png)
![participant_mgmt-participant_form.png](./participant_mgmt-participant_form.png)
