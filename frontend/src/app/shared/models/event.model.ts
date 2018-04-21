export class EventListModel {
  constructor(
    public Id: number,
    public HostName: string,
    public Address: string,
    public StartDate: Date,
    public Title: string,
    public Category: string
  ) {}
}
