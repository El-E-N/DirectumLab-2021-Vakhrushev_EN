import * as React from 'react';
import Deck from '../deck/deck';
import Results from '../results/results';
import {withRouter, RouteComponentProps} from 'react-router-dom';
import Menu from '../menu/menu';
import './main-page.css';

const deck = [
  {value: '0', isChecked: false},
  {value: '0.5', isChecked: false},
  {value: '1', isChecked: false},
  {value: '2', isChecked: false},
  {value: '3', isChecked: false},
  {value: '5', isChecked: false},
  {value: '8', isChecked: false},
  {value: '13', isChecked: false},
  {value: '20', isChecked: false},
  {value: '40', isChecked: false},
  {value: '100', isChecked: false},
  {value: '?', isChecked: false},
  {value: '∞', isChecked: false},
  {value: 'coffee', isSvg: true, isChecked: false}
];

interface IMatchParams {
  id: string;
}

interface IProps extends RouteComponentProps<IMatchParams> {
  roomName: string;
  name?: string;
  onShowModal?(): void;
  isAuthentication: boolean;
}

interface IState {
  isPlanning: boolean;
  addEnterStory: boolean;
  cardSelected: string | null;
}

export class MainPage extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.state = {
      isPlanning: true,
      addEnterStory: false,
      cardSelected: null,
    };
    this.handleClick = this.handleClick.bind(this);
    this.handleSelectedCard = this.handleSelectedCard.bind(this);
  }

  public handleClick() {
    this.setState({
      isPlanning: false,
      addEnterStory: true,
    });
  }

  public handleSelectedCard(value: string | null) {
    this.setState({
      cardSelected: value,
    });
  }

  public render() {
    return <main className="room">
      <h2 className="room-name">{this.props.roomName}</h2>
      <div className="room-content">
        {this.state.isPlanning ?
          <Deck values={deck} onSetSelectedCard={this.handleSelectedCard}/> :
          <Results onShowModal={this.props.onShowModal}/>}
        <Menu
          addEnter={this.state.addEnterStory}
          onClick={this.handleClick}
          newName={this.props.name}
          cardSelected={this.state.cardSelected}
        />
      </div>
    </main>;
  }

  componentDidMount() {
    !this.props.isAuthentication && this.props.history.push(`/invite/${this.props.match.params.id}`);
  }
}

export default withRouter(MainPage);
