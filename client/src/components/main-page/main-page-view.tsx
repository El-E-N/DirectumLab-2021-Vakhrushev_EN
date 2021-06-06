import * as React from 'react';
import Deck from '../deck/deck';
import {RouteComponentProps} from 'react-router-dom';
import Menu from '../menu/menu';
import {RoutePath} from '../../routes';
import {IRoom, IPlayer, IVote, IDiscussion} from '../../store/types';
import BrieflyResults from '../briefly-results/briefly-results';
import History from '../history/history';
import * as discussionApi from '../../api/discussion-api';
import './main-page.css';

interface IMatchParams {
  hash: string;
}

export interface IMainPageProps extends RouteComponentProps<IMatchParams> {
  room: IRoom | null;
  player: IPlayer | null;
  vote: IVote | null;
  discussions: Array<IDiscussion>;
  voteArray: {[key: string]: IVote | null} | null;
  discussionEndAt: string | null;
  loadingRoom(hash: string, choosedDiscussionId: string | null): void;
  updateVote(voteId: string, cardId: string): void;
  getVote(discussionId: string, discussions: Array<IDiscussion>, user: IPlayer): IVote | null;
  createVote(roomId: string, playerId: string, discussionId: string): void;
  createNewVote(roomId: string, playerId: string, discussionId: string): void;
  createDiscussion(roomId: string): void;
  changeChoosedDiscussion(discussionId: string): void;
}

export class MainPageView extends React.Component<IMainPageProps> {
  constructor(props: IMainPageProps) {
    super(props);
    this.handleClick = this.handleClick.bind(this);
  }

  private discussionsCount = 0; // в state происходит предупреждение при изменении в render

  private intervalId: any;

  public async handleClick() {
    if (this.props.room !== null && this.props.room.currentDiscussionId !== null) {
      await discussionApi.closeDiscussionRequest(this.props.room.currentDiscussionId);
      this.props.loadingRoom(this.props.room.hash, this.props.room?.choosedDiscussionId);
      const voteArray = this.props.voteArray;
      for (const key in voteArray) {
        const vote = voteArray[key];
        if (vote !== null) {
          if (vote.card === null) {
            const questionCard = this.props.room.cards.find((card) => card.value === '?');
            if (questionCard !== undefined) this.props.updateVote(vote.id, questionCard.id);
          }
        }
      }
    }
  }

  public updateDiscussionsCount() {
    const {room, vote, player, discussions} = this.props;
    if (
      (vote === null || vote === undefined) 
      && room !== null 
      && player !== null 
      && room.currentDiscussionId !== null 
      && discussions !== null 
      && discussions.length > this.discussionsCount
    ) {
      this.props.createNewVote(room.id, player.id, room.currentDiscussionId);
      this.discussionsCount = discussions.length;
    }
  }

  public render() {
    const {room, vote, player, discussions} = this.props;
    this.updateDiscussionsCount();
    return (room && player && discussions) ?
      <main className="room">
        <h2 className="room-name">{room && room.name}</h2>
        <div className="room-content">
          <div className="results">
            {this.props.discussionEndAt === null ?
              vote && <Deck
                room={room}
                updateVote={this.props.updateVote}
                vote={vote}
              /> :
              this.props.voteArray && <BrieflyResults room={room} voteArray={this.props.voteArray} discussions={discussions}/>}
            {this.props.discussions &&
            <History 
              discussions={discussions} 
              room={room}
              changeChoosedDiscussion={this.props.changeChoosedDiscussion}
              loadingRoom={this.props.loadingRoom}
            />}
          </div>

          <Menu
            showResults={this.props.discussionEndAt !== null}
            onClick={this.handleClick}
            room={room}
            player={player}
            discussions={discussions}
            getVote={this.props.getVote}
            loadingRoom={this.props.loadingRoom}
            createDiscussion={this.props.createDiscussion}
          />
        </div>
      </main> :
      null;
  }

  async componentDidMount() {
    await this.props.loadingRoom(this.props.match.params.hash, null);

    
    if (this.props.room === null)
      this.props.history.push(`/error`);
    else {
      if (this.props.player === null)
        this.props.history.push(`${RoutePath.INVITE}/${this.props.match.params.hash}`);
      
      this.intervalId = await setInterval(() => {
        if (this.props.player !== null && this.props.room !== null)
          this.props.loadingRoom(this.props.match.params.hash, this.props.room.choosedDiscussionId)
      }, 5000);
    }
  }

  componentWillUnmount() {
    clearInterval(this.intervalId);
  }
}

export default MainPageView;
