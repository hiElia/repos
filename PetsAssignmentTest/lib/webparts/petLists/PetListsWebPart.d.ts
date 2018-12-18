import { BaseClientSideWebPart } from '@microsoft/sp-webpart-base';
export interface IPetListsWebPartProps {
    description: string;
}
export default class PetListsWebPart extends BaseClientSideWebPart<IPetListsWebPartProps> {
    onInit(): Promise<void>;
    render(): void;
}
