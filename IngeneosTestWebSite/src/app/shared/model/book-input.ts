export class BookInput {
    idAuthor!: number;
    initialPublishDate?: Date;
    finalPublishDate?: Date;

    public BookInput(){
        this.idAuthor = 0;
    }
}