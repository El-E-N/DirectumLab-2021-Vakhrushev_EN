import * as React from 'react';
import Header from '../header/header';
import Room from '../room/room';
import Footer from '../footer/footer';
import MiddleOpacity from '../middle-opacity/middle-opacity';
import Modal from '../modal/modal';

const ResultWithModal: React.FunctionComponent = () => {
  return <React.Fragment>
    <Header addUser={true}/>
    <Room isPlanning={false}/>
    <Footer />
    <MiddleOpacity/>
    <Modal/>
  </React.Fragment>;
};

export default ResultWithModal;
