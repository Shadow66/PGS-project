export class EventModel {
  constructor(
    public id: number,
    public hostName: string,
    public address: string,
    public startDate: Date,
    public endDate: Date,
    public title: string,
    public category: string,
    public description: string
  ) {}
}
