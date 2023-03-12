import { observer } from "mobx-react-lite";
import { useEffect, useState } from "react";
import { Button, ButtonGroup, Header, Segment } from "semantic-ui-react";
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useStore } from "../../app/stores/store";
import { ##Class## } from "../../app/models/##Class##";
import { Link, useNavigate, useParams } from "react-router-dom";
import MyTextInput from "../../app/common/form/MyTextInput";
import MyDateInput from "../../app/common/form/MyDateInput";



export default observer(function ##Class##Details() {
    const { ##Class##Store } = useStore();
    const { loadItem, item, loading, updateItem, createItem, deleteItem } = ##Class##Store;
    const { id } = useParams();
    const navigate = useNavigate();

    const [##Class##, set##Class##] = useState<##Class##>({
        id: '',
        title: '',
    });
    
    const validationSchema = Yup.object({
        title: Yup.string().required('The event title is required'),       
    });

    useEffect(() => {
             
        if (id){
            loadItem(id).then(it =>{ 
                debugger;
                set##Class##(it!)
            });
        } 
        
    }, [id, loadItem])

    function handleFormSubmit(##Class##: ##Class##, action : any) {
        debugger
        if (##Class##.id.length === 0) {
            let new##Class## = {
                ...##Class##
            };

            createItem(new##Class##).then( (newID) => {
                action.setSubmitting(false)
                navigate(`/##Class##Details/${newID}`)
            } )
        } else {            
            updateItem(##Class##).then(() => {
                action.setSubmitting(false)
                navigate(`/##Class##Details/${##Class##.id}`)
            })

        }
    }

    function handleDelete() {
        if (id) deleteItem(id).then(() => navigate('/##Class##List/'))
    }

    if (##Class##Store.loadingInitial) return <LoadingComponent content='Loading ##Class## details' />

    return (
        <Segment clearing>
            <Header content='##Class## Details' sub color='teal' />
            <Formik
                enableReinitialize
                validationSchema={validationSchema}
                initialValues={##Class##}
                onSubmit={(values, action) => handleFormSubmit(values, action)}>
                {({ handleSubmit, isValid, isSubmitting, dirty }) => (
                    <Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>
                        <MyTextInput name='title' placeholder='Title' />
                        <ButtonGroup variant="contained"  aria-label="contained primary button group">
                            <Button disabled={ isSubmitting || !dirty || !isValid} loading={loading} floated='right' positive type='submit' content='Submit' />                                                
                            <Button onClick={handleDelete} content='Delete' floated='right' type='button' />
                            <Button as={Link} to='/##Class##List' floated='right' type='button' content='Cancel' /> 
                        </ButtonGroup>
                        
                    </Form>
                )}
            </Formik>
        </Segment>        
    )
})