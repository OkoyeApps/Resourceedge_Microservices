import React, { useState, useEffect } from 'react'
import KeyResultDetails from './KeyResultDetails';


const KeyDetailParent = ({ kraIndex, totalkra }) => {
	const [AllKeyResultDetailsArray, setKeyResultDetailsArray] = useState([]);

	useEffect(() => {
		RenderResultDetails();
	}, [])

	const RenderResultDetails = () => {
		var generatedResult = Array.from({ length: totalkra }).map((x, index) => {
			return <KeyResultDetails KraIndex={kraIndex} currentIndex={index} next={true} />
		})
		setKeyResultDetailsArray(generatedResult);
	}

	const showActiveComponent = () => {
		return AllKeyResultDetailsArray[kraIndex] ?? <KeyResultDetails KraIndex={kraIndex} currentIndex={0} /> ;
	}
	return (
		showActiveComponent()
	)
}

export default KeyDetailParent;