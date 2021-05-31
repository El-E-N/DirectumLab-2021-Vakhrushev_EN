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
  discussions: Array<IDiscussion> | null;
  voteArray: {[key: string]: IVote | null} | null;
  loadingRoom(hash: string): IRoom;
  updateVote(voteId: string, cardId: string): void;
  getVote(discussionId: string, discussions: Array<IDiscussion>, user: IPlayer): IVote | null;
  loadingDiscussions(roomId: string): void;
  createVote(roomId: string, playerId: string, discussionId: string): void;
  changeShownModal(activated: boolean): void;
  createNewVote(roomId: string, playerId: string, discussionId: string): void;
  createDiscussion(roomId: string): void;
}

interface IState {
  isPlanning: boolean;
}

export class MainPageView extends React.Component<IMainPageProps, IState> {
  constructor(props: IMainPageProps) {
    super(props);
    this.state = {
      isPlanning: true,
    };
    this.handleClick = this.handleClick.bind(this);
    this.onShowPlanningClick = this.onShowPlanningClick.bind(this);
  }

  public async handleClick() {
    this.setState({
      isPlanning: false,
    });
    if (this.props.room !== null && this.props.room.currentDiscussionId !== null) 
      await discussionApi.closeDiscussionRequest(this.props.room.currentDiscussionId);
  }

  public onShowPlanningClick() {
    this.setState({
      isPlanning: true,
    });
  }

  public async createVote(room: IRoom, player: IPlayer, currentDiscussionId: string) {
    await this.props.createNewVote(room.id, player.id, currentDiscussionId);
  }

  public render() {
    const {room, vote, player, discussions} = this.props;
    console.log(discussions);
    if (vote === null && room !== null && player !== null && room.currentDiscussionId !== null) 
      this.createVote(room, player, room.currentDiscussionId);
    return (room && player && discussions) ?
      <main className="room">
        <h2 className="room-name">{room && room.name}</h2>
        <div className="room-content">
          <div className="results">
            {this.state.isPlanning ?
              vote && <Deck
                room={room}
                updateVote={this.props.updateVote}
                vote={vote}
              /> :
              this.props.voteArray && <BrieflyResults room={room} voteArray={this.props.voteArray}/>}
            {this.props.discussions &&
            <History discussions={discussions} changeShownModal={this.props.changeShownModal}/>}
          </div>

          <Menu
            addEnter={!this.state.isPlanning}
            onClick={this.handleClick}
            room={room}
            player={player}
            discussions={discussions}
            getVote={this.props.getVote}
            loadingRoom={this.props.loadingRoom}
            createDiscussion={this.props.createDiscussion}
            showPlanning={this.onShowPlanningClick}
          />
        </div>
      </main> :
      null;
  }

  async componentDidMount() {
    this.props.room === null && await this.props.loadingRoom(this.props.match.params.hash);

    if (this.props.player === null) {
      this.props.history.push(`${RoutePath.INVITE}/${this.props.match.params.hash}`);
    } else {
      this.props.room && await this.props.loadingDiscussions(this.props.room.id);

      await setInterval(() => {
        this.props.loadingRoom(this.props.match.params.hash);
      }, 9999000);

      const currentDiscussion = this.props.discussions && this.props.discussions[this.props.discussions.length - 1];

      (this.props.room !== null && this.props.player !== null && currentDiscussion !== null) ?
      await this.props.createVote(this.props.room.id, this.props.player.id, currentDiscussion.id) :
      null;
    }
  }
}

export default MainPageView;
