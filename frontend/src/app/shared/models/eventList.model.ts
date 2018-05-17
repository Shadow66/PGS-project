export class EventListModel {
  constructor(
    public id: number,
    public hostName: string,
    public address: string,
    public startDate: Date,
    public title: string,
    public category: string,
    public participants: number
  ) {}
}
