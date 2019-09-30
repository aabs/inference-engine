﻿using System;
using System.Linq;
using Autofac;
using infer_core;
using NUnit.Framework;
using VDS.RDF;
using VDS.RDF.Query;
using VDS.RDF.Update;

namespace infer_tests
{
    public class Owl2EntailmentTests : RdfTestBase
    {

        [Test]
        public void TestCanRunInference()
        {
            _assert("a:subj", "owl:sameAs", "a:obj");
            _assertd("a:subj", "a:p1", "hello");
            _assertd("a:subj", "a:p2", "world");
            Assert.That(_tripleStore.Triples.Count(), Is.EqualTo(3));
            var inf = _container.Resolve<IInferenceEngine>();
            inf.Infer();
            Assert.That(_tripleStore.Triples.Count(), Is.Not.EqualTo(3));
        }

        [Test]
        public void TestSameAsPropogatesProperties()
        {
            _assert("a:subj", "owl:sameAs", "a:obj");
            _assertd("a:subj", "a:p1", "hello");
            _assertd("a:subj", "a:p2", "world");
            var b = qname("a:obj");
            var p1 = qname("a:p1");
            var p2 = qname("a:p2");
            var results1 = _inferences.GetTriplesWithSubjectPredicate(b, p1);
            var results2 = _inferences.GetTriplesWithSubjectPredicate(b, p1);
            Assert.That(results1, Is.Empty);
            Assert.That(results2, Is.Empty);
            var inf = _container.Resolve<IInferenceEngine>();
            inf.Infer();
            results1 = _inferences.GetTriplesWithSubjectPredicate(b, p1);
            results2 = _inferences.GetTriplesWithSubjectPredicate(b, p1);
            Assert.That(results1, Is.Not.Empty);
            Assert.That(results2, Is.Not.Empty);
        }

    }
}