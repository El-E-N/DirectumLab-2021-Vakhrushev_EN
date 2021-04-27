import * as React from 'react';
import Deck from '../deck/deck';
import Results from '../results/results';
import {withRouter, RouteComponentProps} from 'react-router-dom';
import Menu from '../menu/menu';
import './main-page.css';

const deck = [
  {value: '0', isChecked: false, onChange() {}},
  {value: '0.5', isChecked: false, onChange() {}},
  {value: '1', isChecked: false, onChange() {}},
  {value: '2', isChecked: false, onChange() {}},
  {value: '3', isChecked: false, onChange() {}},
  {value: '5', isChecked: false, onChange() {}},
  {value: '8', isChecked: false, onChange() {}},
  {value: '13', isChecked: false, onChange() {}},
  {value: '20', isChecked: false, onChange() {}},
  {value: '40', isChecked: false, onChange() {}},
  {value: '100', isChecked: false, onChange() {}},
  {value: '?', isChecked: false, onChange() {}},
  {value: '∞', isChecked: false, onChange() {}},
  {value: 'coffee', isSvg: true, isChecked: false, onChange() {}}
];

interface IMatchParams {
  id: string;
}

interface IProps extends RouteComponentProps<IMatchParams> {
  roomName: string;
  name: string;
  onShowModal?(): void;
  onShowUser?(): void;
  isAuthentication: boolean;
}

interface IState {
  isPlanning: boolean;
  addEnterStory: boolean;
  cardSelected: boolean;
}

export class MainPage extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.state = {
      isPlanning: true,
      addEnterStory: false,
      cardSelected: false,
    };
    this.handleClick = this.handleClick.bind(this);
    this.props.onShowUser && this.props.onShowUser();
  }

  public handleClick() {
    // eslint-disable-next-line no-console
    console.log(this.MainDeck.state.selectedItem);
    /* this.setState({
      isPlanning: false,
      addEnterStory: true,
    });*/
  }

  MainDeck: Deck = new Deck({values: deck})

  public render() {
    !this.props.isAuthentication && this.props.history.push(`/invite/${this.props.match.params.id}`);
    return <main className="room">
      <h2 className="room-name">{this.props.roomName}</h2>
      <div className="room-content">
        {this.state.isPlanning && this.MainDeck.render()}
        {!this.state.isPlanning && <Results onShowModal={this.props.onShowModal}/>}
        <Menu
          addEnter={this.state.addEnterStory}
          onClick={this.handleClick}
          newName={this.props.name}
          cardSelected={true}
        />
      </div>
    </main>;
  }
}

export default withRouter(MainPage);
