export class EditEventModel {
  constructor(
    public id: number,
    public address: string,
    public startDate: Date,
    public endDate: Date,
    public title: string,
    public category: string,
    public description: string
  ) {}
}
