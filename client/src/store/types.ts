export interface IUser {
  id: string;
  name: string;
}

export interface IRoom {
  id: string;
  hash: string;
  name: string;
  cards: Array<string>;
  selectedCard: string | null;
  hostId: string;
  creatorId: string;
  users: Array<IUser>;
}

export interface IStory {
  id: string;
  name: string | null;
  average: number | null;
  votes: { [key: string]: string }; // key - userId, value - vote
}

export interface IRootState {
  room: IRoom | null;
  stories: Array<IStory>;
  user: IUser | null;
}
